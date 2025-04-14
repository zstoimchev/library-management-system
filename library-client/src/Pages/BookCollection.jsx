import React, {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {fetchBooks} from "../Store/bookSlice";

const BookCollection = () => {
    const dispatch = useDispatch();
    const books = useSelector((state) => state.books.books);
    const authors = useSelector((state) => state.authors.authors);
    const [pageNumber, setPageNumber] = useState(1);
    const pageSize = 10;

    useEffect(() => {
        dispatch(fetchBooks({ pageNumber, pageSize }));
    }, [pageNumber, dispatch]);

    const handleNextPage = () => {
        setPageNumber(pageNumber + 1);
        dispatch({ type: "books/setPageNumber", payload: pageNumber });
    };

    const handlePrevPage = () => {
        if (pageNumber > 1) {
            setPageNumber(pageNumber - 1);
            dispatch({ type: "books/setPageNumber", payload: pageNumber });
        }
    };

    return (<div className="container mt-4">
        <h2 className="text-center">Book Collection</h2>

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
            {books.map((book, index) => {
                const author = authors.find((a) => a.id === book.authorId);
                return (<tr key={book.id}>
                    <td>{(pageNumber - 1) * pageSize + (index + 1)}</td>
                    <td>{book.title}</td>
                    <td>{author ? author.name : "Unknown"}</td>
                    <td>{book.publicationYear}</td>
                </tr>)
            })}
            </tbody>
        </table>
        <div className="d-flex justify-content-center align-items-center mt-4">
            <button
                className="btn btn-primary mx-2" disabled={pageNumber === 1}
                onClick={handlePrevPage}>
                Prev
            </button>

            <span className="fs-5 mx-3">Page {pageNumber}</span>

            <button className="btn btn-primary mx-2"
                    onClick={handleNextPage}>
                Next
            </button>
        </div>

    </div>);
};

export default BookCollection;
