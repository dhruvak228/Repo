import { useState } from "react";
import axios from "axios";

const DeleteEmp = (props) =>{
    const [apiData,setApiData] = useState({userid:""});

    const deleteEmp = (event) =>{
        event.preventDefault();
        axios.delete(`http://localhost:5206/api/employee/${apiData.empid}`);
    }

    const handleChange= (event) =>{
        const {name,value} = event.target
        setApiData({...apiData,[name]:value})
    }

    return(
        <>
        <br/><br/>
        <h4>Enter Employee's empid to be deleted.</h4>
        <form method="get" onSubmit={deleteEmp} >
            <input type="text" name="empid" onchange={handleChange} placeholder="empid" />
            <input type="submit"/>
        </form>
        </>
    );
}
export default DeleteEmp;