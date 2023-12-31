using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WorkerService
    {
            public static List<WorkerDTO> Get()
            {
                var data = DataAccessFactory.WorkerData().Read();
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Worker, WorkerDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<List<WorkerDTO>>(data);
                return mapped;

            }
            public static WorkerDTO Get(int id)
            {
                var data = DataAccessFactory.WorkerData().Read(id);
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Worker, WorkerDTO>();
                });
                var mapper = new Mapper(cfg);
                var mapped = mapper.Map<WorkerDTO>(data);
                return mapped;

            }



    }
}
