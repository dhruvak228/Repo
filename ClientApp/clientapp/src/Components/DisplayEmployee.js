import { useEffect,useState } from "react";
import axios from 'axios';

const DisplayEmployee = (props) =>{
    const [apiData,setApiData] = useState([]);
    useEffect(
        ()=>{
            axios.get('http://localhost:5206/api/EmployeeCrudOps').then(response => {setApiData(response.data)});
        }
     )

     var tablerows = apiData.map(obj =>{
        return (
            <tr>
                <td>{obj.empid}</td>
                <td>{obj.empname}</td>
                <td>{obj.job}</td>
                <td>{obj.joiningdate}</td>
            </tr>
        );
     });

     return(
        <>
        <br></br><br></br>
        <table id="employeeTable">
            <tr>
                <td>EmpId</td>
                <td>EmpName</td>
                <td>Job</td>
                <td>JoiningDate</td>
            </tr>
            {tablerows}
        </table>
        </>
     );
}
export default DisplayEmployee;