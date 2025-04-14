import React, {useEffect} from "react";
import {useDispatch, useSelector} from "react-redux";
import {fetchAuthors} from "../Store/authorSlice";

const AddEditBook = () => {
    const dispatch = useDispatch();
    const authors = useSelector((state) => state.authors.authors);
    const status = useSelector((state) => state.authors.status);

    useEffect(() => {
        if (status === "idle") {
            dispatch(fetchAuthors());
        }
    }, [status, dispatch]);

    return (
        <div className="container mt-4">
            <h2 className="text-center">Add New Book</h2>
            <form className="p-4 bg-light rounded shadow">
                <div className="mb-3">
                    <label htmlFor="bookName" className="form-label">Name of the Book</label>
                    <input type="text" className="form-control" id="bookName" placeholder="Enter book name" />
                </div>

                <div className="mb-3">
                    <label htmlFor="publicationYear" className="form-label">Publication Year</label>
                    <input type="number" className="form-control" id="publicationYear" placeholder="Enter publication year" />
                </div>

                <div className="mb-3">
                    <label htmlFor="authorSelect" className="form-label">Author of the Book</label>
                    <select className="form-select" id="authorSelect">
                        <option value="">Select an author</option>
                        {authors.map((author) => (
                            <option key={author.id} value={author.id}>{author.name}</option>
                        ))}
                    </select>
                </div>

                <button type="submit" className="btn btn-primary w-100">Submit</button>
            </form>
        </div>
    );
};

export default AddEditBook;
