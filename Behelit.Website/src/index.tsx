import * as ReactDOM from 'react-dom';
import { PublicLayout } from 'layouts';
import { ThemeProvider } from 'providers';
import React from 'react';

ReactDOM.render(
  <React.StrictMode>
    <ThemeProvider>
      <PublicLayout />
    </ThemeProvider>
  </React.StrictMode>,
  document.getElementById('root')
);
