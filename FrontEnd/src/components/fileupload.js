import React,{ useState } from "react";

export const FileUpload=()=>{
    const[file,setFile] =useState();

    const saveFile=(e)=>{
        console.log(e.target.files[0]);
        setFile(e.target.files[0]);
    }

    const uploadFile = async(e)=>{
        console.log(file);
        const formData = new FormData();
        formData.append("Files",file);
        const res = await fetch("https://localhost:5001/Store/Item/Create",{
            method:"POST",
            body:formData
        })
    }
    return(
        <div>
            <input type="file" onChange={saveFile}/>
            <input type='button' value = "upload" onClick={uploadFile}></input>
        </div>
    )
}