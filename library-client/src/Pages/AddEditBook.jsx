import React, {useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {fetchBooks} from "../Store/bookSlice";

const AddEditBook = () => {
    const [state, setState] = useState({success: false, msg: ""});
    const authors = useSelector((state) => state.authors.authors);
    const [book, setBook] = React.useState({name: "", publicationYear: "", authorId: ""});
    const dispatch = useDispatch();

    const handleChange = (e) => {
        setBook({
            ...book, [e.target.name]: e.target.value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!book.name || !book.publicationYear || !book.authorId) {
            setState({success: false, msg: "Please fill all fields!"});
            return;
        }

        try {
            const response = await fetch("http://localhost:5144/books", {
                method: "POST", headers: {
                    "Content-Type": "application/json",
                }, body: JSON.stringify({
                    Title: book.name, PublicationYear: book.publicationYear, AuthorId: book.authorId,
                }),
            });

            if (!response.ok) {
                console.error("Failed to submit book");
                setState({success: false, msg: "Invalid format"});
                return
            }
            console.log("Book added successfully!");
            setState({success: true, msg: "Book added successfully!"});
            dispatch(fetchBooks({pageNumber: 1, pageSize: 10}));
        } catch (error) {
            console.error(error);
            setState({success: false, msg: "Error adding book"});
        }
    };

    return (<div className="container mt-4" onSubmit={handleSubmit}>
        <h2 className="text-center">Add New Book</h2>
        <form className="p-4 bg-light rounded shadow">
            <div className="mb-3">
                <label htmlFor="bookName" className="form-label">Name of the Book</label>
                <input type="text" className="form-control" id="bookName" name="name"
                       placeholder="Enter book name" onChange={handleChange}/>
            </div>

            <div className="mb-3">
                <label htmlFor="publicationYear" className="form-label">Publication Year</label>
                <input type="number" className="form-control" id="publicationYear" name="publicationYear"
                       placeholder="Enter publication year" onChange={handleChange}/>
            </div>

            <div className="mb-3">
                <label htmlFor="authorSelect" className="form-label">Author of the Book</label>
                <select className="form-select" id="authorSelect" value={book.authorId}
                        name="authorId" onChange={handleChange}>
                    <option value="">Select an author</option>
                    {authors.map((author) => (<option key={author.id} value={author.id}>{author.name}</option>))}
                </select>
            </div>

            <button type="submit" className="btn btn-primary w-100">Submit</button>

            {!state.success && !state.msg ? null :
                <div className={`alert alert-${state.success ? "success" : "danger"} mt-3`} role="alert">
                    {state.msg}
                </div>}
        </form>
    </div>);
};

export default AddEditBook;
