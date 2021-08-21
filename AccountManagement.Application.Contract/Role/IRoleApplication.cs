﻿using _01_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Role
{
    public interface IRoleApplication
    {
        List<RoleViewModel> GetAll();
        EditRole GetDetail(long id);
        OperationResult Create(CreateRole command);
        OperationResult Edit(EditRole command);
    }
}