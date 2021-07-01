import * as ReactDOM from 'react-dom';
import React from 'react';
import App from 'scenes/App';

const render = () => {
  ReactDOM.render(
    <React.StrictMode>
      <App />
    </React.StrictMode>,
    document.getElementById('root')
  );
};

if (module.hot) {
  module.hot.accept('scenes/App', function () {
    console.log('Accepting the updated printMe module!');
    render();
  });
}

render();
