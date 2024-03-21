import { useState } from "react";
import IUser from "../../../models/IUser";
import User from "../user/user";
import "./add-user.css"
import mcApi from "../../../services/mcApi";
import { useNavigate } from "react-router-dom";

function AddUser() {
    const navigate = useNavigate();
    const{ AddExecutor } = mcApi
    const [UserData, setUserData] = useState<IUser>({} as IUser);

    function onChangeUserNickName(event: any) {
        const nickName = event.target.value;
        setUserData(user => {
            const newUser = {...user, nickName}
            return newUser
        });
    }

    function onChangeUserEmail(event: any) {
        const email = event.target.value;
        setUserData(user => {
            const newUser = {...user, email}
            return newUser
        });
    }

    function onChangeUserPassword(event: any) {
        const password = event.target.value;
        setUserData(user => {
            const newUser = {...user, password}
            return newUser
        });
    }

    function onChangeUserTemplate(event: any) {
        const data = event.target.value;
        setUserData(user => {
            const newUser = {...user, data}
            return newUser
        });
    }

    function onCreateUserClick(): void {
        AddExecutor(UserData)
            .then(({data}) => {
                navigate(`/user/profile/${data}`)
        })
    }

    return ( 
        <div>
            <h2>Добавить исполнителя</h2>
            <div className="add-user-container">
                <div className="add-user">
                    <div>
                        <input type="text" placeholder="Имя" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Фамилия" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Ник на сайте" onChange={onChangeUserNickName}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Электронная почта" onChange={onChangeUserEmail}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Пароль для пользователя" onChange={onChangeUserPassword}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Номер телефона" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="date" placeholder="Выберите дату" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Уровень доступа" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Компания" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <input type="text" placeholder="Проект" onChange={onChangeUserTemplate}/>
                    </div>
                    <div>
                        <button onClick={onCreateUserClick}>Create user</button>
                    </div>
                </div>
                <div className="user-preview">
                    <User user = {UserData}></User>
                </div>
            </div>
        </div>
     );
}

export default AddUser;