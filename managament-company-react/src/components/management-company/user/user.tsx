import { FC } from "react";
import IUser from "../../../models/IUser";
import { Link } from "react-router-dom";
import "./user.css"

interface UserProps {
    user: IUser, 
    onRemove?: (id: number) => void
}
 
const User: FC<UserProps> = ({user, onRemove}) => {
    return ( 
        <div>
            <div>
              <span className="base-info-text">Name:</span> {user.nickName} 
                </div>
                    <span className="base-info-text">Id:</span> ({user.id})
                <div>
                </div>
                    <span className="base-info-text">Email:</span> {user.email}
                <div>
                </div>
                    <span className="base-info-text">Password:</span> {user.password}
                <div>
            </div>
              <Link to={`/user/profile/${user.id}`}>Profile</Link>
              <div>
                <span onClick={() => onRemove?.(user.id)} className="remove"> Remove</span>
              </div>
            </div>
     );
}
 
export default User;