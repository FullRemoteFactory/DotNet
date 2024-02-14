// TravelInfoPage.js
import React, { useState } from 'react';
import { useQuery, gql } from '@apollo/client';

const GET_TRAVEL_INFO = gql`
  query GetTravelInfo($firstName: String!, $lastName: String!) {
    client(firstName: $firstName, lastName: $lastName) {
      id
      firstName
      lastName
      dossier {
        id
        type
        arrivalDate
        duration
        flightNumber
        location
      }
    }
  }
`;

const TravelInfoPage = () => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  
  const { loading, error, data } = useQuery(GET_TRAVEL_INFO, {
    variables: { firstName, lastName },
  });

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error.message}</p>;

  const { client } = data;

  return (
    <div>
      <h1>Travel Information</h1>
      <form>
        <label>
          First Name:
          <input type="text" value={firstName} onChange={(e) => setFirstName(e.target.value)} />
        </label>
        <label>
          Last Name:
          <input type="text" value={lastName} onChange={(e) => setLastName(e.target.value)} />
        </label>
        <button type="submit">Submit</button>
      </form>
      {client && (
        <div>
          <h2>{client.firstName} {client.lastName}</h2>
          <p>Dossier Type: {client.dossier.type}</p>
          <p>Arrival Date: {client.dossier.arrivalDate}</p>
          <p>Duration: {client.dossier.duration}</p>
          <p>Flight Number: {client.dossier.flightNumber}</p>
          <p>Location: {client.dossier.location}</p>
        </div>
      )}
    </div>
  );
};

export default TravelInfoPage;
