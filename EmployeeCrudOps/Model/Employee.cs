namespace EmployeeCrudOpsApi.Model;

using System.ComponentModel.DataAnnotations;

public class Employee{
    public int empid{get;set;}

    [Required]
    public string empname{get;set;} ="";

    [Required]
    public string job{get;set;} = "";

    [Required]
    public string joiningdate{get;set;} = "";

}