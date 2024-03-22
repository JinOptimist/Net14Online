import { FC } from "react";
import { IBond } from "../../Models/IBond";
import './bond.css'

interface BondProps {
    bond: IBond,
    isFullDetailse?: boolean,
    onRemove?: (id: number) => void
}

const Bond: FC<BondProps> = ({ bond, onRemove }) => { 
    return (
        <div className="bond">
            {bond.name}
            {<span onClick={() => onRemove?.(bond.id)} className="remove"> Remove</span>}
        </div>
    );
}

export default Bond;