import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
    return (
        <nav className="navbar navbar-dark bg-dark fixed-top d-flex justify-content-center p-3">
            <div className="container d-flex justify-content-center gap-5">
                <Link to="/" className="btn btn-outline-secondary">Book Collection</Link>
                <Link to="/add-book" className="btn btn-outline-secondary">Add/Edit Book</Link>
                <Link to="/add-author" className="btn btn-outline-secondary">Add Author</Link>
            </div>
        </nav>
    );
};

export default Navbar;
