﻿namespace File.Repositorie.IRepositorie
{
    using File.Repositorie.EntitieRepositorie;
    using System.Collections.Generic;

    public interface ICustomerContactsPqaRepositorie
    {
        public IEnumerable<CustomerContactsRepoEntitie> GetContacts(string idEmpresa);
    }
}