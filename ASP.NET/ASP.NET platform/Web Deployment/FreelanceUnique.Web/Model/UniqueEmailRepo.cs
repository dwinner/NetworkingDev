using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using FreelanceUnique.Web.Model.Edm;

namespace FreelanceUnique.Web.Model
{
    public class UniqueEmailRepo : IDisposable
    {
        private readonly EmailEntities _emailContext;

        public UniqueEmailRepo()
        {
            _emailContext = new EmailEntities();
        }

        public IEnumerable<UniqueEmail> Emails
        {
            get { return _emailContext.UniqueEmails; }
        }

        public void Dispose()
        {
            _emailContext.Dispose();
        }

        public bool IsUnique(UniqueEmail email)
        {
            return
                !Enumerable.Any(_emailContext.UniqueEmails,
                    eml => email.Email.Equals(eml.Email, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<bool> SaveAsync(UniqueEmail email)
        {
            if (email.EmailId == 0)
            {
                _emailContext.UniqueEmails.Add(email);
            }
            else
            {
                var uniqueEmail = _emailContext.UniqueEmails.Find(email.EmailId);
                if (uniqueEmail != null)
                {
                    uniqueEmail.UserId = email.UserId;
                    uniqueEmail.Email = email.Email;
                }
            }

            try
            {
                return await _emailContext.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public UniqueEmail GetEmail(int emailId)
        {
            return _emailContext.UniqueEmails.FirstOrDefault(email => email.EmailId == emailId);
        }

        public async Task<bool> UpdateAsync(int emlId, string emailValue)
        {
            var email = await _emailContext.UniqueEmails.FindAsync(emlId);
            if (email != null)
            {
                email.Email = emailValue;
                try
                {
                    return await _emailContext.SaveChangesAsync() > 0;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
                catch (DbUpdateException)
                {
                    return false;
                }
                catch (DbEntityValidationException)
                {
                    return false;
                }
                catch (InvalidOperationException)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int emlId)
        {
            var email = await _emailContext.UniqueEmails.FindAsync(emlId);
            if (email != null)
            {
                _emailContext.UniqueEmails.Remove(email);
                return await _emailContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}