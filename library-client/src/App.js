import {BrowserRouter as Router, Routes, Route, Navigate} from "react-router-dom";
import Layout from "./Components/Layout.jsx";
import BookCollection from "./Pages/BookCollection.jsx";
import AddEditBook from "./Pages/AddEditBook.jsx";
import AddAuthor from "./Pages/AddAuthor.jsx";
import {useEffect} from "react";
import {fetchBooks} from "./Store/bookSlice";
import {fetchAuthors} from "./Store/authorSlice";
import {useDispatch} from "react-redux";

function App() {
    const dispatch = useDispatch();
    const pageNumber = 1;
    const pageSize = 10;

    useEffect(() => {
        dispatch(fetchBooks({ pageNumber, pageSize }));
        dispatch(fetchAuthors());
    }, [dispatch]);
    return (<Router>
        <Layout>
            <Routes>
                <Route path="/" element={<BookCollection/>}/>
                <Route path="/add-edit-book" element={<AddEditBook/>}/>
                <Route path="/add-author" element={<AddAuthor/>}/>
                <Route path="*" element={<Navigate to="/" replace/>}/>
            </Routes>
        </Layout>
    </Router>);
}

export default App;
