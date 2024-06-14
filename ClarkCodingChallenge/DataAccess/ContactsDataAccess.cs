using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.DataAccess
{
    public class ContactsDataAccess
    {
        private static List<Contact> contacts = new List<Contact>();

        public static void AddContact(Contact c)
        {
            contacts.Add(c);
            if (contacts.Count > 0 )
                contacts.Sort((x, y) => string.Compare(x.lastName, y.lastName));
        }

        /* Returns a list of contacts matching a given last name, or all the contacts
         * currently stored if not provided with one. SortFlag determines whether the 
         * list is sorted in ascending or descending order.
         * (1 = Ascending, 0 = Descending)
         */
        public static List<Contact> GetContacts(string lastName, int sortFlag)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                if (sortFlag == 1)
                    return contacts;
                else
                    contacts.Reverse();
                return contacts;
            }

            List<Contact> requestedContacts = new List<Contact>();
            requestedContacts = contacts.FindAll(x => x.lastName == lastName);
            if (sortFlag == 1)
                return requestedContacts;
            else
                requestedContacts.Reverse();
                return requestedContacts;
        }
    }
}
