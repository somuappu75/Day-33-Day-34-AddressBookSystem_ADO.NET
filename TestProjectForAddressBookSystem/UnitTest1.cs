using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSystem_ADO.NET;

namespace TestProjectForAddressBookSystem
{
    [TestClass]
    public class AddressBookTesting
    {
        AddressBookRepo addressBookRepository;
        [TestInitialize]

        public void SetUp()
        {
            addressBookRepository = new AddressBookRespitory();
        }

        //Usecase 2:Ability to insert new Contacts to Address Book
        [TestMethod]
        public void TestMethodInsertIntoTable()
        {
            int expected = 1;
            ContactDataManager addressBook = new ContactDataManager();
            addressBook.FirstName = "Rani";
            addressBook.LastName = "Malvi";
            addressBook.Address = "Baker's Street";
            addressBook.City = "Chennai";
            addressBook.State = "TamilNadu";
            addressBook.zip = 243022;
            addressBook.PhoneNumber = 9842905050;
            addressBook.Email = "rani@gmail.com";
            addressBook.AddressBookName = "FriendName";
            addressBook.Type = "Friends";
            int actual = addressBookRepository.InsertIntoTable(addressBook);
            Assert.AreEqual(expected, actual);
        }
    }
}

