import React, { useState } from 'react';
import { FiSearch } from "react-icons/fi";
import { useDispatch } from 'react-redux';
import { setSearchQuery } from '../../redux/features/ventas-slice';
import './search-bar.css';

interface SearchBoxProps {}

export const SearchBox: React.FC<SearchBoxProps> = () => {
    const dispatch = useDispatch();
    const [query, setQuery] = useState("");

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        const { value } = event.target;
        setQuery(value);
        dispatch(setSearchQuery(value)); 
    };

    // const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    //     event.preventDefault();
    // };

    return (
        <form
            aria-label="form-search"
            className="container-form"
            // onSubmit={handleSubmit}
        >
            <div className="input-group">
                <input
                    type="text"
                    autoFocus
                    className="form-control"
                    name="search"
                    placeholder="Search"
                    value={query}
                    onChange={handleChange}
                />
            </div>
            <div className="input-group-append">
                <button className="btn btn-search" type="submit">
                    <FiSearch />
                </button>
            </div>
        </form>
    );
};
