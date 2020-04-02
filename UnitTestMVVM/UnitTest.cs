
using System;
using System.Collections.Generic;
using HotelMVVM2020Demo.Persistency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary;

namespace UnitTestMVVM
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodAddHotel()
        {
            //Arrange
            HotelPersistencyFacade facade= new HotelPersistencyFacade();
            List<Hotel> hoteller = facade.GetHotelsAsync().Result;
            int AntalBeforeInsert = hoteller.Count;

            //Act
            Hotel newHotel = new Hotel(500,"Test","Test");
            bool ok = facade.PostAsync(newHotel).Result;
            hoteller = facade.GetHotelsAsync().Result;
            int AntalAfterInsert = hoteller.Count;

            facade.DeleteAsync(500);


            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(AntalBeforeInsert+1, AntalAfterInsert);

        }

        [TestMethod]
        public void TestDeleteAddHotel()
        {
            //Arrange
            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            bool okadd = facade.PostAsync(new Hotel(501,"TestDelete","TestDelete")).Result;
            List<Hotel> hoteller = facade.GetHotelsAsync().Result;
            int AntalBeforedelete = hoteller.Count;

            //Act
            
            bool ok = facade.DeleteAsync(501).Result;
            hoteller = facade.GetHotelsAsync().Result;
            int AntalAfterdelete = hoteller.Count;


            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(AntalBeforedelete -1, AntalAfterdelete);

        }

        [TestMethod]
        public void TestPutHotel()
        {
            //Arrange
            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            bool okadd = facade.PostAsync(new Hotel(502, "Testputbefore", "Testputbefore")).Result;

            //Act
            Hotel putHotel = new Hotel(502, "Testput", "Testput");
            bool ok = facade.PutAsync(502, putHotel).Result;
            List<Hotel> hoteller = facade.GetHotelsAsync().Result;
            Hotel hotelInList = facade.GetHotelAsync(502).Result;
            bool okdelete = facade.DeleteAsync(502).Result;

            //Assert
            Assert.AreEqual(true, ok);
            Assert.AreEqual(putHotel, hotelInList);
            
        }
    }
}
