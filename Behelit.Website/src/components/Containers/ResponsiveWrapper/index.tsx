import { ReactNode } from 'react';
import styled from 'styled-components';

const Wrapper = styled.div`
  width: 100%;
  height: 100%;
`;

const Responsive = styled.div`
  width: 100%;
  height: 100%;
  margin: 0 auto;

  @media (min-width: ${(props) => props.theme.breakpoints.sm}) {
    width: 700px;
  }

  @media (min-width: ${(props) => props.theme.breakpoints.md}) {
    width: 1000px;
  }

  @media (min-width: ${(props) => props.theme.breakpoints.lg}) {
    width: 1200px;
  }
`;

interface Props {
  children: ReactNode;
}
const ResponsiveWrapper = ({ children }: Props) => (
  <Wrapper>
    <Responsive>{children}</Responsive>
  </Wrapper>
);

export default ResponsiveWrapper;
