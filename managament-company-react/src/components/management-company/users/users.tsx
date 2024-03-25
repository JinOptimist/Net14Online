import { useEffect, useState } from "react";
import IUser from "../../../models/IUser";
import './users.css'
import User from "../user/user";
import { Link } from "react-router-dom";
import mcApi from "../../../services/mcApi";

const Users = () => {
  const { getUsers, deleteExecutor } = mcApi;
  const [Users, setUsers] = useState<IUser[]>([]);

  useEffect(() => {
    getUsers()
      .then(({data}) => {
        setUsers(data as IUser[])
    })
  }, []);
  
  const onAddUserClick = () => {
    const newUser = {
      id: 3,
      nickName: 'Guest'
    }

    setUsers(oldUsersData => [...oldUsersData, newUser]);
  }

  function deleteUser(id: number): void {
    setUsers(oldUsersData => oldUsersData.filter(user => user.id !== id));
  }

    return (
      <div>
        <div>
          Всего у нас {Users.length} пользователей.
        </div>
        <div>
          <Link to="add-user">Add user</Link>
        </div>
        <button onClick={onAddUserClick}>New user</button>
          {Users.map(user => (
            <User user={user} onRemove={deleteExecutor} key={user.id}></User>
        ))}
      </div>
    );
  }
  
  export default Users;