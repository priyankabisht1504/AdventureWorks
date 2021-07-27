using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAccessLayer;

namespace BusinessLayer
{
    public class DepartmentBAL
    {
        public List<DepartmentModel> GetAllDepartment()
        {
            List<DepartmentModel> DepartmentsList = new List<DepartmentModel>();
            using (var context = new AdventureWorks2014Entities())
            {
                DepartmentsList = context.Departments.OrderByDescending(d => d.DepartmentID).Select(d => new DepartmentModel
                {
                    DepartmentId = d.DepartmentID,
                    DepartmentName = d.Name,
                    GroupName = d.GroupName,
                    ModifiedDate = d.ModifiedDate
                }).ToList();
            }
            return DepartmentsList;
        }

        public int AddDepartment(DepartmentModel department)
        {
            int result = 0;
            try
            {
                using (var context = new AdventureWorks2014Entities())
                {
                    context.Departments.Add(new Department
                    {
                        Name = department.DepartmentName,
                        GroupName = department.GroupName,
                        ModifiedDate = DateTime.Now

                    });
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            using (var context = new AdventureWorks2014Entities())
            {
                var DepartmentDetails = context.Departments.Where(m => m.DepartmentID == departmentId).Select(m => new DepartmentModel
                {
                    DepartmentName = m.Name,
                    GroupName = m.GroupName
                }).FirstOrDefault();
                return DepartmentDetails;

            }
        }

        public int UpdateDepartment(DepartmentModel departmentModel)
        {
            int result = 0;
            try
            {
                using (var Context = new AdventureWorks2014Entities())
                {
                    var department = Context.Departments.SingleOrDefault(m => m.DepartmentID == departmentModel.DepartmentId);
                    if (department != null)
                    {
                        department.Name = departmentModel.DepartmentName;
                        department.GroupName = departmentModel.GroupName;
                        department.ModifiedDate = DateTime.Now;
                    }
                    result = Context.SaveChanges();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteDepartment(int departmentId)
        {
            int result = 0;
            using(var Context= new AdventureWorks2014Entities())
            {
                var department = Context.Departments.First(m => m.DepartmentID == departmentId);
                Context.Departments.Remove(department);

                result = Context.SaveChanges();

            }
            return result;
        }
    }
}
