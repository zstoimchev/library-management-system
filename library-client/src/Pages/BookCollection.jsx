import React, {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {fetchBooks} from "../Store/bookSlice";
// import bootstrap
import "bootstrap/dist/css/bootstrap.min.css";

const BookCollection = () => {
    const dispatch = useDispatch();
    const books = useSelector((state) => state.books.books);
    const authors = useSelector((state) => state.authors.authors);
    const [pageNumber, setPageNumber] = useState(1);
    const pageSize = 10;
    const [query, setQuery] = useState({payload: ""});
    const [searchedBooks, setSearchedBooks] = useState([]);
    const totalPages = useSelector((state) => state.books.totalPages);

    useEffect(() => {
        dispatch(fetchBooks({pageNumber, pageSize}));
    }, [pageNumber, dispatch]);

    const handleNextPage = () => {
        setPageNumber(pageNumber + 1);
        dispatch({type: "books/setPageNumber", payload: pageNumber});
    };

    const handlePrevPage = () => {
        if (pageNumber > 1) {
            setPageNumber(pageNumber - 1);
            dispatch({type: "books/setPageNumber", payload: pageNumber});
        }
    };

    const handleChange = (e) => {
        setQuery({
            ...query, [e.target.name]: e.target.value
        });
    };

    const handleSearch = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`http://localhost:5144/books/search?query=${(query.payload)}`)
            if (response.status === 404) {
                console.error("No books found");
                return;
            }
            if (!response.ok) {
                console.error("Failed to fetch books");
                return;
            }
            const data = await response.json();
            setSearchedBooks(data);
        } catch (error) {
            console.error(error);
        }
    }

    const handleDelete = async (id) => {
        try {
            const response = await fetch(`http://localhost:5144/books/${id}`, {
                method: "DELETE"
            });
            if (!response.ok) {
                console.error("Failed to delete book");
                return;
            }
            dispatch(fetchBooks({pageNumber, pageSize}));
        } catch (error) {
            console.error(error);
        }
    }

    return (<div className="container mt-4">
        <h2 className="text-center">Book Collection</h2>
        <form className="d-flex align-items-center">
            <input type="text" onChange={handleChange} className="form-control me-2" id="payload"
                   placeholder="Search a book" name="payload" value={query.payload} />
            <button type="submit" className="btn btn-primary me-2" name="payload" onClick={handleSearch}>Search</button>
            <button type="button" className="btn btn-danger" onClick={() => {
                setSearchedBooks([])
                setQuery({payload: ""})
            }}>Clear
            </button>
        </form>

        <table className="table table-striped table-bordered mt-2">
            <thead className="table-dark">
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Author</th>
                <th>Publication Year</th>
                <th>Action</th>
            </tr>
            </thead>
            <tbody>
            {(searchedBooks.length > 0 ? searchedBooks : books).map((book, index) => {
                const author = authors.find((a) => a.id === book.authorId);
                return (<tr key={book.id}>
                    <td>{(pageNumber - 1) * pageSize + (index + 1)}</td>
                    <td>{book.title}</td>
                    <td>{author ? author.name : "Unknown"}</td>
                    <td>{book.publicationYear}</td>
                    <td>
                        <button className="btn btn-sm btn-outline-danger" onClick={() => handleDelete(book.id)}>Delete
                        </button>
                    </td>
                </tr>)
            })}
            </tbody>
        </table>

        {totalPages > 1 && (
            <div className="d-flex justify-content-center align-items-center mt-4">
                <button className="btn btn-primary mx-2" disabled={pageNumber === 1}
                        onClick={() => setPageNumber(1)}>
                    <i className="bi bi-chevron-double-left m-2"></i> First
                </button>

                <button className="btn btn-primary mx-2" disabled={pageNumber === 1}
                        onClick={handlePrevPage}>
                    <i className="bi bi-arrow-left m-2"></i> Prev
                </button>

                <span className="fs-5 mx-3">Page {pageNumber} of {totalPages}</span>

                <button className="btn btn-primary mx-2" disabled={pageNumber === totalPages}
                        onClick={handleNextPage}>
                    Next <i className="bi bi-arrow-right m-2"></i>
                </button>

                <button className="btn btn-primary mx-2" disabled={pageNumber === totalPages}
                        onClick={() => setPageNumber(totalPages)}>
                    Last <i className="bi bi-chevron-double-right m-2"></i>
                </button>
            </div>
        )}

    </div>);
};

export default BookCollection;
