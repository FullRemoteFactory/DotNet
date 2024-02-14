// index.js
import React from 'react';
import ReactDOM from 'react-dom';
import { ApolloProvider, ApolloClient, InMemoryCache } from '@apollo/client';
import './index.css';
import App from './App';

const client = new ApolloClient({
  uri: 'http://localhost:5000/api/graphql', // Remplacez par l'URL de votre API GraphQL
  cache: new InMemoryCache(),
});

ReactDOM.render(
  <ApolloProvider client={client}>
    <React.StrictMode>
      <App />
    </React.StrictMode>
  </ApolloProvider>,
  document.getElementById('root')
);
