import React, {useState} from "react";
import "bootstrap/dist/css/bootstrap.min.css"; // Ensure Bootstrap is imported

const AddAuthor = () => {
    const [author, setAuthor] = useState({name: "", bday: ""});

    const handleChange = (e) => {
        setAuthor({...author, [e.target.id]: e.target.value});
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch("https://localhost:7081/authors", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(author),
            });

            if (!response.ok) {
                console.error("failed to add author");
            }

            console.log("Author added successfully!");
            setAuthor({ name: "", dob: "" });
        } catch (error) {
            console.error("Error adding author:", error);
        }
    };

    return (<div className="container mt-4">
        <h2 className="text-center">Add Author</h2>
        <form onSubmit={handleSubmit} className="p-4 bg-light rounded shadow">
            <div className="mb-3">
                <label htmlFor="authorName" className="form-label">Author Name</label>
                <input type="text" className="form-control"
                       onChange={handleChange} id="authorName" placeholder="Enter author name"/>
            </div>

            <div className="mb-3">
                <label htmlFor="dateOfBirth" className="form-label">Date of Birth</label>
                <input type="date" className="form-control" onChange={handleChange} id="dateOfBirth"/>
            </div>

            <button type="submit" className="btn btn-primary w-100">Submit</button>
        </form>
    </div>);
};

export default AddAuthor;
