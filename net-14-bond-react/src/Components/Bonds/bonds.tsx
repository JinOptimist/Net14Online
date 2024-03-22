import { useState } from "react";
import { IBond } from "../../Models/IBond";
import './Bonds/bonds.css'
import Bond from "../Bond/bond";

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
            id: 10,
            name: 'ОФЗ',
            price: 1000
        }
        setBond(currentBondsData => [...currentBondsData, newBond]);
    }

    function removeBond(id: any): void {
        setBond(currentBondsData => currentBondsData.filter(bond => bond.id !== id));
    }

    return (
        <div>
            <button onClick={onAddBondClick}>Add bond</button>

            {Bonds.map(bond => (
                <Bond bond = {bond} onRemove = {removeBond}></Bond>
            ))}
        </div>
    );
}

export default Bonds;