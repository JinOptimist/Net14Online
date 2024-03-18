import { useState } from "react";
import { IBond } from "../Models/IBond";
import './Bonds/bonds.css'

const Bonds = () => {
    const [Bonds, setBond] = useState<IBond[]>([
        {
            id: 1,
            name: 'Sber',
            price: 1500
        },
        {
            id: 2,
            name: 'ALRS',
            price: 2000
        }
    ]);

    const onAddBondClick = () => {
        const newBond = {
            id:10,
            name: 'ОФЗ',
            price: 1000
        }
        setBond(currentBondsData =>[...currentBondsData, newBond]);
    }

    return (
        <div>
            <button onClick={onAddBondClick}>Add bond</button> <span className="delete">Delete</span>
            {Bonds.map(bond=>(
                <div>{bond.name}</div>
            ))}
        </div>
    );
}

export default Bonds;