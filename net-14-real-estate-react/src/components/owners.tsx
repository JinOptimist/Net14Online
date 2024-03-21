import { useEffect, useState } from "react"
import IOwner from "../models/IOwner"
import './Owner.css'
import Owner from "./Owner/owner"
import { Link } from "react-router-dom"
import realestateApi from "../services/realEstateApi"


function Owners() {

  const { getOwners,deleteOwner} = realestateApi;
  const [OwnerName,setOwner] = useState<IOwner[]>([
    {
      id: 1,
      name: 'Mikola',
      age:43,
      kindOfActivity : 'rent'
    },
    {
      id: 2,
      name: 'Sveta',
      age:23,
      kindOfActivity:'rent'
    }
  ])

  useEffect(() => {
    getOwners()
    .then(({data}) =>{
      setOwner(data as IOwner[])
    })
  },[]);

  const onClickName = () => {
   const newOwner = (
    {
      id:3,
      name: 'Jack',
      age: 30,
      kindOfActivity:'rent'
    }
   )

   setOwner(oldData =>[...oldData,newOwner]);
  }

  function removeOwner(id:number): void {
    deleteOwner(id);
    setOwner(OwnerName.filter(item => item.id !== id));
  }

  return (
       <div>
        <Link to="AddOwner">AddOwner</Link>
         <button onClick={onClickName}>Add Owner</button>
          {OwnerName.map(owner => (
           <Owner owner={owner} onRemove={removeOwner}></Owner>
          ))}
      </div>
    );
  }
  
export default Owners