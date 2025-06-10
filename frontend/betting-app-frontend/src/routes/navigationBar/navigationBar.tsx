import { Fragment } from 'react';
import { Link, Outlet } from "react-router-dom";
import './style.css'

const NavigationBar = () => {
    return (
        <Fragment>
            <nav className="navbar">
                <div className="navbar-brand">Bet to win</div>
                <div className="navbar-links">
                    <Link to="/">Home</Link>
                    <Link to="/about">About</Link>
                    <Link to="/contact">Contact</Link>
                </div>
            </nav>
            <main className="main-container">
                <Outlet />
            </main>
        </Fragment>
    );
}

export default NavigationBar