﻿import React, { Component } from 'react';
import axios from 'axios';

export class Trips extends Component
{
    constructor(props) {
        super(props);

        this.state = {
            trips: [],
            loading: true
        }
    }


    componentDidMount() {
        this.populateTripsData();
    }

    populateTripsData() {
        axios.get("api/Trips/GetTrips").then(result => {
            debugger;
            const response = result.data;
            this.setState({ trips: response, loading: false });
        })
    }


    renderAllTripsTable(trips) {
        debugger;
        return (
           
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Name </th>
                        <th>Description </th>
                        <th>DateStarted </th>
                        <th>Date completed </th>
                        <th>Action </th>
                    </tr>
                </thead>

                <tbody>
                    {
                        trips.map(trip => (
                            <tr key={trip.id}>
                                <td>{trip.name}</td>
                                <td>{trip.description}</td>
                                <td>{new Date(trip.dateStarted).toLocaleString()}</td>
                                <td>{trip.completed ? new Date(trip.dateCompleted).toLocaleString() : ' - '} </td>
                                <td> - </td>
                            </tr>

                        ))
                    }

   
                </tbody>

            </table>
            );
    }

    render() {

        let content = this.state.loading ? (
            <p>
                <em>Loading...</em>
            </p>    
        ) : (
            this.renderAllTripsTable(this.state.trips)
       )

        return (
            <div>
                <h1>All trips</h1>
                <p>Here you can see all trips</p>
                {content}
            </div>
            );
    }
}