using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.DTOs.Request;
using Kolokwium.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kolokwium.Controllers

{

    [ApiController]
    [Route("api/team-members")]
    public class Kontroler1 : ControllerBase
    {
        private const string ConfString = "Data Source=db-mssql;Initial Catalog=s16696;Integrated Security=True";


        [HttpGet("{id}/tasks")]
        public IActionResult GetInfo([FromRoute] string id)
        {

            if (!string.IsNullOrEmpty(id))
            {
                var listaZadan = new List<TaskModel>();
                using (var connection = new SqlConnection(ConfString))
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    //dla creatora
                    command.CommandText = "Select t.IdTask ,t.Name, t.Description, t.IdCreator, t.IdProject From Task t Join TeamMember mb ON mb.IdTeamMember = t.IdProject AND mb.IdTeamMember = @index";
                    command.Parameters.AddWithValue("index", id);

                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (!dr.Read())
                    {
                        return BadRequest();
                    }

                    while (dr.Read())
                    {
                        TaskModel model = new TaskModel();
                        model.IdTask = dr["IdTask"].ToString();
                        model.Name = dr["Name"].ToString();
                        model.Description = dr["Description"].ToString();
                        model.IdCreator = dr["IdCreator"].ToString();
                        model.IdTeam = dr["IdProject"].ToString();
                        model.czyJestKreatorem = "Nie jest kreatorem";

                        if (model.IdCreator == model.IdTeam)
                        {
                            model.czyJestKreatorem = "Tak jest kreatorem!";
                        }

                        listaZadan.Add(model);
                    }


                }
                return Ok(listaZadan);

            }

            return Ok();
        }




        [Route("api/tasks")]
        [HttpPut("{id}")]
        public IActionResult updateTask([FromRoute] string id, TaskRequest request)
        {
            using (var connection = new SqlConnection(ConfString))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                //dla creatora
                command.CommandText = "Select * From Task Where IdTask = @index;";
                command.Parameters.AddWithValue("index", id);

                connection.Open();
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {

                    var tran = connection.BeginTransaction();
                    TaskModel taskModel = new TaskModel();
                    taskModel.Name = request.Name;
                    taskModel.Description = request.Description;
                    taskModel.Deadline = request.DeadLine;
                    taskModel.IdTeam = request.IdTeam;

                    dr.Close();

                    TaskTypeModel p = request.TaskType;
                    string taskid = p.IdTaskType;
                    command.CommandText = "Select * From TaskType Where IdTaskType =" + taskid;

                    if (!dr.Read())
                    {
                        command.CommandText = "Insert INTO TaskType (idTaskType, Name) Values (" + Int32.Parse(p.IdTaskType) + ", '" + p.Name + ",)";
                    }




                    command.CommandText = "Update task Set Name=@name, Description=@description, Deadline=@deadline, IdTeam=@idteam, IdAssignedTo=@idAssignedTo, IdCreator=@idcreator, IdTaskType=@idTaskType Where IdTask=@index";
                    command.Parameters.AddWithValue("name", request.Name);
                    command.Parameters.AddWithValue("description", request.Description);
                    command.Parameters.AddWithValue("deadline", request.DeadLine);
                    command.Parameters.AddWithValue("idteam", request.IdTeam);
                    command.Parameters.AddWithValue("idAssignedTo", request.IdAssignedTo);
                    command.Parameters.AddWithValue("idcreator", request.IdCreator);
                    command.Parameters.AddWithValue("IdTaskType", p.IdTaskType);


                    tran.Commit();


                }
                else
                {
                    //tworzenie
                }

                return null;
            }



        }
    }



}
