using System.Collections.Generic;
using System.Data.Entity;

namespace DynamicSelectableList.Infrastructure
{
   public class StateContextInitializer : DropCreateDatabaseIfModelChanges<StateContext>
   {
      protected override void Seed(StateContext context)
      {
         var states = new List<State>();
         var cities = new List<City>();

         var tulaState = new State { Id = 1, Name = "Тула" };
         var tulaCities = new List<City>
         {
            new City {Id = 1, Name = "Алексин", State = tulaState, StateId = tulaState.Id},
            new City {Id = 2, Name = "Венев", State = tulaState, StateId = tulaState.Id},
            new City {Id = 3, Name = "Ефремов", State = tulaState, StateId = tulaState.Id},
            new City {Id = 4, Name = "Щекино", State = tulaState, StateId = tulaState.Id},
            new City {Id = 5, Name = "Плавск", State = tulaState, StateId = tulaState.Id}
         };
         tulaState.Cities = tulaCities;

         states.Add(tulaState);
         cities.AddRange(tulaCities);

         var moscowState = new State { Id = 2, Name = "Москва" };
         var moscowCities = new List<City>
         {
            new City {Id = 1, Name = "Щёлково", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "Электрогорск", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "Электросталь", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "Ногинский", State = moscowState, StateId = moscowState.Id},
            new City {Id = 1, Name = "Яхрома", State = moscowState, StateId = moscowState.Id}
         };
         moscowState.Cities = moscowCities;

         states.Add(moscowState);
         cities.AddRange(moscowCities);

         states.ForEach(state => context.States.Add(state));
         cities.ForEach(city => context.Cities.Add(city));

         base.Seed(context);
      }
   }
}