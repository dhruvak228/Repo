import { useState } from "react";
import axios from "axios";

const InsertEmployee = (props) =>{
    const [apiData,setApiData] = useState({empname:"",job:"",joiningdate:""});

    const savedata = (event)=>{
        event.preventDefault();
        axios.post('http://localhost:5206/api/EmployeeCrudOps',apiData);

    }

    const handleChange=(event)=>{
        const {name,value} = event.target
        setApiData({...apiData,[name]:value})
    }

    return(
        <>
          <br/><br/>
          <h4>Add new Employee</h4>
          <form method="POST" onSubmit={savedata}>
            <input type="text" name="empname" onChange={handleChange} placeholder="empname" />
            <input type="text" name="job" onChange={handleChange} placeholder="job" />
            <input type="text" name="joiningdate" onChange={handleChange} placeholder="joiningdate" />
            <input type="Submit" />
          </form>
        </>
    );
}
export default InsertEmployee;