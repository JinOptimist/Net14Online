import { FC } from "react";
import IOwner from "../../models/IOwner";

interface OwnerProps{
    owner: IOwner
    onRemove?: (id: number) => void
} 

const Owner: FC<OwnerProps> = ({owner,onRemove}) => {
    return(
        <div>
            {owner.name} ({owner.id})
            <span onClick={() => onRemove?.(owner.id)} className="remove">X</span>
        </div>
    );
}

export default Owner;