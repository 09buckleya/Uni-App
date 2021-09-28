//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using NAA.Data.Models.Domain;
//using NAA.OutServices.Models;
//using NAA.OutServices.IService;
//using NAA.OutServices.Service;
//namespace NAA.OutServices.Service
//{
//    public class Service : IContract
//    {
//        NAA.Services.IService.IApplicationService applicationService;
//        public Service()
//        {
//            applicationService = new NAA.Services.Service.ApplicationService();
//        }
//        public Category GetApplication(int applicationId)
//        {
//            return applicationService.GetApplication(applicationId);
//        }
        //Record[] GetRecords(IList<Application> applicationList)
        //{
        //    Record[] list = new Record[applicationList.Count];
        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        list[i] = new NAA.OutServices.Models.Record
        //        {
        //            ApplicationId = applicationList[i].ApplicationId,
        //            Course = applicationList[i].Course,
        //            Statement = applicationList[i].Statement,
        //            TeacherContact = applicationList[i].TeacherContact,
        //            TeacherReference = applicationList[i].TeacherReference,
        //            Offer = applicationList[i].Offer,
        //            Firm = applicationList[i].Firm
        //        };
        //    }
        //    return list;
        //}
        //public Category[] GetApplicants()
        //{
        //    IList<User> userList = userService.GetUsers().ToList();
        //    Category[] array = new Category[userList.Count];
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        array[i] = new Category
        //        {
        //            ID = userList[i].UserId,
        //            Name = userList[i].Name,
        //            Address = userList[i].Address,
        //            Phone = userList[i].Phone,
        //            Email = userList[i].Email,
        //            Records = GetRecords(userList[i].Applications.ToList())
        //        };
        //    }
        //    return array;
        //}
//    }
//}
