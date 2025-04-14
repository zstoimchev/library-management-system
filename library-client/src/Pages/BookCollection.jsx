import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchBooks } from "../Store/bookSlice";

const BookCollection = () => {
    const dispatch = useDispatch();
    const books = useSelector((state) => state.books.books);
    const status = useSelector((state) => state.books.status);

    useEffect(() => {
        if (status === "idle") {
            dispatch(fetchBooks());
        }
    }, [status, dispatch]);

    return (
        <div className="container mt-4">
            <h2 className="text-center">Book Collection</h2>

            {status === "loading" && <p>Loading books...</p>}
            {status === "failed" && <p>Error loading books.</p>}

            <table className="table table-striped table-bordered">
                <thead className="table-dark">
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Author</th>
                    <th>Publication Year</th>
                </tr>
                </thead>
                <tbody>
                {books.map((book) => (
                    <tr key={book.id}>
                        <td>{book.id}</td>
                        <td>{book.title}</td>
                        <td>{book.author}</td>
                        <td>{book.publicationYear}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
};

export default BookCollection;
