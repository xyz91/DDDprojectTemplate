using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MediPlus.Domain.IRepositories;
using MediPlus.Domain.Model;
using MediPlus.DTO;
using MediPlus.Service.Base;
using MediPlus.Service.Interface;

namespace MediPlus.Service
{
   public class UserService: BaseService,IUserService
    {
        private IUserRepository userRepository;
        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public UserDTO GetUser(int id) {
            var user = userRepository.GetById(id);
            return Map<UserDTO>(user); 
        }
    }
}
