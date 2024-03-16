import { useState } from "react"
import IOwner from "../models/IOwner"
import './Owner.css'
import Owner from "./Owner/owner"


function Owners() {

  const [OwnerName,setOwner] = useState<IOwner[]>([
    {
      id: 1,
      name: 'Mikola'
    },
    {
      id: 2,
      name: 'Sveta'
    }
  ])

  const onClickName = () => {
   const newOwner = (
    {
      id:3,
      name: 'Jack'
    }
   )

   setOwner(oldData =>[...oldData,newOwner]);
  }

  function removeOwner(id:number): void {
     setOwner(oldData => oldData.filter(x=> x.id !== id))
  }

  return (
       <div>
         <button onClick={onClickName}>Add Owner</button>
          {OwnerName.map(owner => (
           <Owner owner={owner} onRemove={removeOwner}></Owner>
          ))}
      </div>
    );
  }
  
export default Owners