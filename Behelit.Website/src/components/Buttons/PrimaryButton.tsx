import { PropsWithChildren } from 'react';
import styled from 'styled-components';

const StyledButton = styled.button<{ width: string }>`
  width: ${(props) => props.width};
  padding: 0.5rem 1rem;
  background: ${(props) => props.theme.colors.tertiary};
  color: ${(props) => props.theme.colors.white};
  border: none;
  cursor: pointer;

  &:hover {
    background: ${(props) => props.theme.colors.quinary};
    color: ${(props) => props.theme.colors.tertiary};
  }
`;

interface Props {
  onClick?: () => void;
  width?: string;
}

const PrimaryButton = ({ children, width = '100%', ...rest }: PropsWithChildren<Props>) => (
  <StyledButton width={width} {...rest}>
    {children}
  </StyledButton>
);

export default PrimaryButton;
