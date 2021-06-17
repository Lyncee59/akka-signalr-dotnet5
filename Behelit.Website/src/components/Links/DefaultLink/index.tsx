import { forwardRef, ReactNode } from 'react';
import styled from 'styled-components';

const StyledLink = styled.a`
  margin: 0 1rem;
  color: ${(props) => props.theme.colors.typography};
  text-decoration: none;

  &:hover {
    color: ${(props) => props.theme.colors.tertiary};
    text-decoration: underline;
  }
`;

interface Props {
  children: ReactNode;
}

const DefaultLink = forwardRef<HTMLAnchorElement, Props>((props, ref) => <StyledLink ref={ref} {...props} />);

export default DefaultLink;
