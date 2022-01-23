// using Domain;
// using Microsoft.Data.SqlClient;
// using Microsoft.EntityFrameworkCore;
//
// namespace Data
// {
//     public static class DbFunctions
//     {
//         private static readonly AssignmentsContext Db = new();
//
//         public static byte GetModuleTotal(string moduleId)
//         {
//             string query = $"SELECT dbo.fn_getModuleTotal('{moduleId}') 'Total'";
//             return Db.ModuleTotalFunction.FromSqlRaw(query).FirstOrDefault()!.Total;
//         }
//
//         public static IEnumerable<ModuleDetails> GetModuleDetails(string moduleId)
//         {
//             string query = $"SELECT ModuleName, AssignmentName, Grade FROM dbo.fn_getModuleDetails('{moduleId}')";
//             return Db.ModuleDetailsFunction.FromSqlRaw(query).ToList();
//         }
//
//         public static Guid GetCourseId(string course)
//         {
//             return Db.Course
//                     .SingleOrDefault(c => c.CourseName.ToLower().Equals(course.ToLower()))!
//                 .CourseID;
//         }
//
//         public static string GetModuleId(string module)
//         {
//             return Db.Module
//                     .SingleOrDefault(m => m.ModuleName.ToLower().Equals(module.ToLower()))!
//                 .ModuleID;
//         }
//
//         public static Guid GetTypeId(string type)
//         {
//             return Db.Type
//                     .SingleOrDefault(t => t.AssignmentType.ToLower().Equals(type.ToLower()))!
//                 .TypeId;
//         }
//
//         public static void AddAssignment(string name, string module, string type, byte maxMark, DateTime startDate, DateTime endDate)
//         {
//             var nameParam = new SqlParameter("name", name);
//             var moduleParam = new SqlParameter("module", module);
//             var typeParam = new SqlParameter("type", type);
//             var markParam = new SqlParameter("mark", maxMark);
//             var startParam = new SqlParameter("start", startDate);
//             var endParam = new SqlParameter("end", endDate);
//
//             Db.Database.ExecuteSqlRaw("EXEC dbo.sp_addAssignment @name, @module, @type, @mark, @start, @end",
//                 nameParam, moduleParam, typeParam, markParam, startParam, endParam);
//         }
//
//         #region Function Related Classes
//         [Keyless]
//         public class ModuleTotal
//         {
//             public ModuleTotal()
//             {
//                 Total = 0;
//             }
//
//             public byte Total { get; }
//         }
//
//         [Keyless]
//         public class ModuleDetails
//         {
//             public string ModuleName { get; set; } = null!;
//             public string AssignmentName { get; set; } = null!;
//             public string Grade { get; set; } = null!;
//         }
//         #endregion
//     }
// }