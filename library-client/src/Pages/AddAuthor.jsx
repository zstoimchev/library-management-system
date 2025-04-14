import React, {useState} from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import {useDispatch} from "react-redux";
import {fetchAuthors} from "../store/authorSlice";

const AddAuthor = () => {
    const [author, setAuthor] = useState({Name: "", dateOfBirth: ""});
    const [state, setState] = useState({success: false, msg: ""});
    const handleChange = (e) => {
        setAuthor({...author, [e.target.id]: e.target.value});
    };
    const dispatch = useDispatch();

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!author.Name || !author.dateOfBirth) {
            setState({success: false, msg: "Please fill all fields!"});
            return;
        }
        let date = null;
        try {
            date = new Date(author.dateOfBirth);
            date.setUTCHours(0, 0, 0, 0);
            date = date.toISOString();
        } catch (error) {
            console.error("Invalid date format:", error);
            setState({success: false, msg: "Invalid date format"});
            return;
        }

        try {
            const response = await fetch("https://localhost:7081/authors", {
                method: "POST", headers: {
                    "Content-Type": "application/json",
                }, body: JSON.stringify({
                    Name: author.Name, DateOfBirth: date
                }),
            });

            if (!response.ok) {
                console.error("failed to add author");
            }

            console.log("Author added successfully!");
            setState({success: true, msg: "Author added successfully!"});
            dispatch(fetchAuthors());
        } catch (error) {
            console.error("Error adding author:", error);
            setState({success: false, msg: "Error adding author"});
        }
    };

    return (<div className="container mt-4">
        <h2 className="text-center">Add Author</h2>
        <form onSubmit={handleSubmit} className="p-4 bg-light rounded shadow">
            <div className="mb-3">
                <label htmlFor="Name" className="form-label">Author Name</label>
                <input type="text" className="form-control"
                       onChange={handleChange} id="Name" placeholder="Enter author name"/>
            </div>

            <div className="mb-3">
                <label htmlFor="dateOfBirth" className="form-label">Date of Birth</label>
                <input type="date" className="form-control" onChange={handleChange} name="dateOfBirth"
                       id="dateOfBirth"/>
            </div>

            <button type="submit" className="btn btn-primary w-100">Submit</button>

            {!state.success && !state.msg ? null :
                <div className={`alert alert-${state.success ? "success" : "danger"} mt-3`} role="alert">
                    {state.msg}
                </div>}

        </form>
    </div>);
};

export default AddAuthor;
