import React, { Component, useState } from 'react';
import { Badge, Button } from "reactstrap";

export const Counter = ({  }) => {

  const [count, setCount] = useState(0)

  return (
    <div>
      <h1>Counter</h1>
      <p>This is an example react component.</p>
      <p>The current count is: <Badge color="info">{ count }</Badge> </p>
      <Button color="primary" onClick={ () => {setCount(count + 1)} }>Add to counter</Button>
    </div>
  )

}
