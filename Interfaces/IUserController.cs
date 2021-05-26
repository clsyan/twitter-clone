using twitter_clone.Models;

namespace twitter_clone.Interfaces {
    public interface IFollow {
        User Follower { get; }
        User Following { get; }
    }
}