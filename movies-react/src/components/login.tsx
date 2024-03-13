import { useState } from "react";
import '../css/autorithation.css';

export const Login = () => {
    const [showLogin, setShowLogin] = useState<boolean>();

    return (
        <div className="autorithation d-none" id="login">
            <form>
                <button className="btn btn-outline-secondary justify-content-end d-flex button-close" onClick={() => setShowLogin(!showLogin)}>X</button>
                <h3>Вход</h3>

                <label htmlFor="username">Логин</label>
                <input type="text" id="username" autoComplete="username" placeholder="Логин" />

                <label htmlFor="password">Пароль</label>
                <input type="password" id="password" autoComplete="current-password" placeholder="Пароль" />

                <button className="button-auth">Войти</button>
            </form>
        </div>
    );
}