﻿using Authentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Repository.Inteface
{
    public interface IEditorRepository
    {
        Task<bool> userAuthAsync(string name, string password);
        Task<AppUser> GetEditorByNameAsync(string name);
        Task<bool> CreateEditorAsync(AppUser Editor);
        Task<IEnumerable<AppUser>> GetAllEditor();

        //Editor permissions
        Task UpdateContent(Content content);
        Task<bool> GetContentByIdAsync(int contentId);
        Task<IEnumerable<Content>> GetAllContentAsync();
        Task<bool> hasPermissionAsync(string userID, string perm);
    }
}
