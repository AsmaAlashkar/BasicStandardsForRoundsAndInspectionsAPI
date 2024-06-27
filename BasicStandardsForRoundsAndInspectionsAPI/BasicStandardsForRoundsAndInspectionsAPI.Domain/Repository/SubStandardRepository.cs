﻿using BasicStandardsForRoundsAndInspectionsAPI.Domain.Interfaces;
using BasicStandardsForRoundsAndInspectionsAPI.Models;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.MainstandardDTO;
using BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.SubStandardDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.Domain.Repository
{
    public class SubStandardRepository : ISubStandardRepository
    {
        private readonly ApplicationDbContext _context;

        public SubStandardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public SubStandard CreateSubStandard(CreateSubStandardDTO createSubStandardDTO)
        {
            var mainStandardExists = _context.MainStandards.Any(x=> x.Id == createSubStandardDTO.MainStandardId);
            if (mainStandardExists)
            {
                var newSubStandard = new SubStandard
                {
                    Description = createSubStandardDTO.Description,
                    MainStandardId = createSubStandardDTO.MainStandardId
                };
                _context.Add(newSubStandard);
                _context.SaveChanges();
                return newSubStandard;
            }
            return null;
        }

        public IndexSubStandardDTO GetSubStandardById(int id)
        {
            var subStandard = _context.SubStandards.Find(id);
            if (subStandard != null)
            {
                var subStandardDTO = new IndexSubStandardDTO
                {
                    Description = subStandard.Description,
                    MainStandardId = subStandard.MainStandardId
                };
                return subStandardDTO;
            }
            return null;
        }

        public IEnumerable<SubStandard> GetAllSubStandards()
        {
            return _context.SubStandards.OrderBy(s=>s.Id);
        }

        public IEnumerable<IndexSubStandardDTO> GetSubStandardsByMainStandardId(int mainStandardId)
        {
            return _context.SubStandards.Where(s=>s.MainStandardId == mainStandardId).ToList().Select(item=> new IndexSubStandardDTO
            {
                Description= item.Description,
                MainStandardId = item.MainStandardId
            });   
        }

        public SubStandard EditSubStandardById(int id, EditSubStandardDTO editSubStandardDTO)
        {
            var subStandardObj = _context.SubStandards.Find(id);
            if (subStandardObj != null)
            {
                subStandardObj.Description = editSubStandardDTO.Description;
                subStandardObj.MainStandardId = editSubStandardDTO.MainStandardId;
                _context.SaveChanges();
                return subStandardObj;
            }
            return null;
        }

        public bool DeleteSubStandardById(int id)
        {
            var subStandard = _context.SubStandards.Find(id);
            if (subStandard != null)
            {
                _context.Remove(subStandard);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
