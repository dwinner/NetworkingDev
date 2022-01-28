using System.ServiceModel;

namespace CourseOrderServiceContract
{
   [ServiceContract]
   [DeliveryRequirements(QueuedDeliveryRequirements = QueuedDeliveryRequirementsMode.Required)]
   public interface ICourseOrderService
   {
      [OperationContract(IsOneWay = true)]
      void AddCourseOrder(CourseOrder.CourseOrder courseOrder);
   }
}