import styled, { createGlobalStyle } from 'styled-components';
import { Flex } from 'reflexbox';
import { Switch, Route, BrowserRouter, Link } from 'react-router-dom';
import { ResponsiveWrapper } from 'components/Containers';
import { DefaultLink } from 'components/Links';
import Game from 'scenes/Game';
import Home from 'scenes/Home';
import Login from 'scenes/Login';
import Register from 'scenes/Register';
import Test from 'scenes/Test';

const GlobalStyle = createGlobalStyle`
  html, body, #root {
    width: 100%;
    height: 100%;
  }

  * {
    color: ${(props) => props.theme.colors.typography};
    padding: 0;
    margin: 0;
    box-sizing: border-box;
  }
`;

const Wrapper = styled.div`
  background: ${(props) => props.theme.colors.secondary};
  height: 100%;
  width: 100%;
  background: red;
`;

const Header = styled(Flex)`
  width: 100%;
  height: 50px;
  padding: 1rem;
  background: ${(props) => props.theme.colors.primary};
`;

const Content = styled.div`
  height: calc(100% - 50px);
  overflow-y: auto;
`;

const PublicLayout = () => (
  <BrowserRouter>
    <Wrapper>
      <GlobalStyle />
      <Header>
        <ResponsiveWrapper>
          <Flex justifyContent="space-between">
            <div>
              <Link to="/" component={DefaultLink}>
                Home
              </Link>
              <Link to="/game" component={DefaultLink}>
                Game
              </Link>
              <Link to="/test" component={DefaultLink}>
                Test
              </Link>
            </div>
            <div>
              <Link to="/login" component={DefaultLink}>
                Login
              </Link>
              <Link to="/register" component={DefaultLink}>
                Register
              </Link>
            </div>
          </Flex>
        </ResponsiveWrapper>
      </Header>
      <Content>
        <ResponsiveWrapper>
          <Switch>
            <Route path="/game">
              <Game />
            </Route>
            <Route path="/login">
              <Login />
            </Route>
            <Route path="/register">
              <Register />
            </Route>
            <Route path="/test">
              <Test />
            </Route>
            <Route path="/">
              <Home />
            </Route>
          </Switch>
        </ResponsiveWrapper>
      </Content>
    </Wrapper>
  </BrowserRouter>
);

export default PublicLayout;
