import { useState } from "react";
import './authorithation.css';

export const Registration = () => {
    const [showRegistration, setShowRegistration] = useState<boolean>();

    return (
        <div className="autorithation d-none" id="registration">
            <form>
                <button type="button" className="btn btn-outline-secondary justify-content-end d-flex button-close"
                    onClick={() => setShowRegistration(!showRegistration)}>X</button>
                <h3>Регистрация</h3>
                <label htmlFor="loginReg">Логин</label>
                <input type="text" id="loginReg" autoComplete="username" placeholder="Логин" />

                <label htmlFor="email">Почта</label>
                <input type="text" id="email" autoComplete="email" placeholder="Email" />

                <label htmlFor="passReg">Пароль</label>
                <input type="password" id="passReg" autoComplete="new-password" placeholder="Пароль" />

                <label htmlFor="repeatPass">Повторите пароль</label>
                <input type="password" id="repeatPass" autoComplete="new-password" placeholder="Повторите пароль" />

                <button className="button-auth">Зарегестрироваться</button>
            </form>
        </div>
    );
}