import { FC } from "react";
import IOwner from "../../models/IOwner";
import { Link } from "react-router-dom";

interface OwnerProps{
    owner: IOwner
    onRemove?: (id: number) => void
} 

const Owner: FC<OwnerProps> = ({owner,onRemove}) => {
    return(
        <div>
            {owner.name} ({owner.id})
            <span onClick={() => onRemove?.(owner.id)} className="remove">X</span>
          <Link to={`/owner/profile/${owner.id}`}>Profile</Link>
        </div>
    );
}

export default Owner;