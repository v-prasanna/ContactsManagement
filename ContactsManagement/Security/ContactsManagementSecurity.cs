﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactsDBDataAccess;

namespace ContactsManagement.Security
{
    public class ContactsManagementSecurity
    {
        public static bool Login(string username, string password)
        {
            // Verify the credentials against the information in the Users table.
            ContactsDBEntities contactsDBEntities = new ContactsDBEntities();
            return contactsDBEntities.Users.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);            
        }
    }
}