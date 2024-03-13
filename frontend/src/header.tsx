function Header(props: any) {
  return (
    <div>
      <header className="row header navbar navbar-dark bg-dark bg-dark">
        <div className="col subtitle">
          <h1 className="text-white">{props.title}</h1>
        </div>
      </header>
    </div>
  );
}

export default Header;
