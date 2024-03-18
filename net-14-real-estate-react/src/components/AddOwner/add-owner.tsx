import { useNavigate } from "react-router-dom";
import realestateApi from "../../services/realEstateApi";
import IOwner from "../../models/IOwner";
import { useState } from "react";
import Owner from "../Owner/owner";

function AddOwner() {
    const navigate = useNavigate();
    const { addOwner } = realestateApi;
    const [OwnerData, setOwnerData] = useState<IOwner>({} as IOwner);

    const onOwnerNameChange = (evt: any) => {
        const name = evt.target.value
        setOwnerData(oldOwner => {
            const newOwner = { ...oldOwner, name }
            return newOwner
        });
    }

    const onOwnerAgeChange = (evt: any) => {
        const age = evt.target.value
        setOwnerData(oldOwner => {
            const newOwner = { ...oldOwner, age }
            return newOwner
        });
    }

    const onOwnerKindOfActivityChange = (evt: any) => {
        const kindOfActivity = evt.target.value
        setOwnerData(oldOwner => {
            const newOwner = { ...oldOwner, kindOfActivity }
            return newOwner
        });
    }

    function onAddOwnerClick(): void {
        addOwner(OwnerData)
        .then(({ data }) => {
            navigate(`/apartmentowner/profile/${data}`)
            });
    }

    return (
        <div className="add-owner-container">
            <div className="owner-data">
                <div>
                    <input type="text" placeholder="name" onChange={onOwnerNameChange} />
                </div>
                <div className="owner-data">
                    <input type="number" placeholder="age" onChange={onOwnerAgeChange} />
                </div>
                <div className="owner-data">
                    <input type="text" placeholder="kibdOfActivity" onChange={onOwnerKindOfActivityChange} />
                </div>

                <div>
                    <button onClick={onAddOwnerClick}>Create</button>
                </div>
            </div>

            <div className="owner-preview">
                <Owner owner={OwnerData}></Owner>
            </div>
        </div>
    );
}

export default AddOwner;